namespace Advent
open System.Text.RegularExpressions

module Part1 =
    let hasDuplicates (seq: seq<'a>) = 
        let distinctSeq = Seq.distinct seq
        (seq |> Seq.length) <> (distinctSeq |> Seq.length)

    let run(line : string) =
        line.ToCharArray()
        |> Seq.windowed 4
        |> Seq.findIndex(fun x -> not (hasDuplicates x))
        |> (+) 4 // as we are looking for the index of the first non-duplicated char

