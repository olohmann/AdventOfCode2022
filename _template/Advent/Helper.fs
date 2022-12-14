namespace Advent
open System.IO

module Helper =

    let readLines (filePath:string) = seq {
        use sr = new StreamReader (filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine ()
    }

    let readTestInput : string seq =
        readLines "./test-input.txt"

    let readInput : string seq =
        readLines "./input.txt"
