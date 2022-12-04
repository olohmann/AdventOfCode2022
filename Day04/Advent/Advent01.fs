namespace Advent

module Part1 =
    let parseSequence(sequence: string) = 
        let i = sequence.Split("-")
        seq { i[0] |> int .. 1 .. i[1] |> int }

    let parsePairs(line : string) =
        let i = line.Split(",") 
        ( parseSequence(i[0]) |> Set.ofSeq, parseSequence(i[1]) |> Set.ofSeq )

    let runInner(lines : string seq) =
        lines
        |> Seq.map parsePairs
        |> Seq.map (fun x -> if ((fst x).IsSubsetOf(snd x) || (snd x).IsSubsetOf(fst x)) then 1 else 0)
        |> Seq.sum

    let run =
        Helper.readFile() 
        |> runInner
