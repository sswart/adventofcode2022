use std::collections::HashMap;
use std::env;
use std::fs;
use std::collections::hash_map::Entry::Vacant;
use std::collections::hash_map::Entry::Occupied;

fn main() {
    print_calories();

    
}

fn print_calories(){
    let split = get_lines(&"./Day1/input.txt");
    let values = get_values(split);

    let mut a: Vec<i32> = values.into_values().collect();
    a.sort_by(|a,b| b.cmp(&a));
    let top3: i32 = a[0..3].iter().sum();

    println!("Top3 {top3}");
}

fn get_values(split: Vec<String>) -> HashMap<i32, i32> {
    let mut calory_counts: HashMap<i32, i32> = HashMap::new();
    let mut current:Option<i32> = None;
    for line in split{

        if line.is_empty(){
            current = match current{
                Some(val) => Some(val + 1),
                None => Some(0)
            };
            continue;
        }

        if current.is_none(){
            current = Some(0);
        }
    
        let line_value = line.parse::<i32>().expect("Line should be an integer");
        let current_value = match calory_counts.entry(current.unwrap()){
            Vacant(entry) => entry.insert(0),
            Occupied(entry) => entry.into_mut(),
        };
        *current_value += line_value;
    }
    return calory_counts;
}

fn get_lines(file_path: &String) -> Vec<String> {
    let contents = fs::read_to_string(file_path).expect("Should be able to read the file");
    return contents.lines().map(|l| l.to_string()).collect();
}

#[cfg(test)]
mod tests{
    use super::*;

    #[test]
    fn get_lines_not_empty() {
        let lines = get_lines(&"./Day1/input.txt".to_string());
        assert!(!lines.is_empty());
    }


    #[test]
    fn get_values_correct_maximum() {
        let input = ["", "1", "2", "", "8"].map(|s| s.to_string()).to_vec();

        let values = get_values(input);

        assert_eq!(values[&0], 3);
        assert_eq!(values[&1], 8);
    }

    #[test]
    fn get_values_no_empty_start_line() {
        let input = ["1", "2", "", "8"].map(|s| s.to_string()).to_vec();

        let values = get_values(input);

        assert_eq!(values[&0], 3);
        assert_eq!(values[&1], 8);
    }

    #[test]
    fn get_top3(){

    }
}