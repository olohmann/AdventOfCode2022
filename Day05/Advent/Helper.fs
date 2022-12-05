namespace Advent
open System.IO

module Helper =
    let readFile() : string array =
        File.ReadAllLines(@"./input.txt")
