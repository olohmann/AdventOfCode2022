namespace Advent

module Part1 =
    let hasDuplicates (seq: seq<'a>) = 
        let distinctSeq = Seq.distinct seq
        (seq |> Seq.length) <> (distinctSeq |> Seq.length)

    let run (line: string) (windowSize: int) =
        line.ToCharArray()
        |> Seq.windowed windowSize
        |> Seq.findIndex(fun x -> not (hasDuplicates x))
        |> (+) windowSize // as we are looking for the index of the first non-duplicated char

