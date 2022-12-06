

fn parse_moves(lines: Vec<&String>){
    for line in lines{
        let mut split = line.split(' ');

        let char1 = split.next().unwrap().chars().next().unwrap();
        let char2: char = split.next().unwrap().chars().next().unwrap();
        let p1 = parse_move(&char1);
        let p2 = parse_move(&char2);

        let outcome = calc_score(&p1, &p2);
    }
}

fn parse_move(character: &char) -> Box<dyn Move>{
    if character == &'X' || character == &'A'{
        return Box::new(Rock{});
    }
    else if character == &'Y' || character == &'B'{
        return Box::new(Paper{});
    }
    else if character == &'Z' || character == &'C'{
        return Box::new(Scissors{});
    }
    panic!("Unknown character");
}

trait Move {
    fn score(&self) -> i32;
}

fn calc_score<T1: Move, T2: Move>(one: &T1, two: &T2) -> Outcome{
    if (one.score() == two.score()){
        return Outcome::Equal;
    }
    else if one.score() == 1 && two.score() == 2
    || one.score() == 2 && two.score() == 3
    || one.score() == 3 && two.score() == 1{
        return Outcome::Lose;
    }
    return Outcome::Win;
}

struct Rock{}

struct Paper{}
struct Scissors{}
impl Move for Rock{
    fn score(&self) -> i32 {
        return 1;
    }
}

impl Move for Paper{
    fn score(&self) -> i32 {
        return 2;
    }    
}


impl Move for Scissors{
    fn score(&self) -> i32 {
        return 3;
    }
}

enum Outcome{
    Win = 6,
    Equal = 3,
    Lose = 0
}
