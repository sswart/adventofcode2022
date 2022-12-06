fn get_outcome<T1: Move, T2: Move>(one: &T1, two: &T2){

}

trait Move {
    fn score() -> i32;
}

struct Rock{}

struct Paper{}
struct Scissors{}
impl Move for Rock{
    fn score() -> i32 {
        return 1;
    }
}

impl Move for Paper{
    fn score() -> i32 {
        return 2;
    }
}

impl Move for Scissors{
    fn score() -> i32 {
        return 3;
    }
}

enum Outcome{
    Win,
    Equal,
    Lose
}
