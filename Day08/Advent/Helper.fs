namespace Advent
open System.IO

module Helper =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader (filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine ()
    }

    let readTestInput : string list =
        readLines "./test-input.txt" |> Seq.toList

    let readInput : string list =
        readLines "./input.txt" |> Seq.toList
