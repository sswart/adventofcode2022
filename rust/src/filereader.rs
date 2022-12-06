use std::fs;

pub fn get_lines(file_path: &String) -> Vec<String> {
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
}