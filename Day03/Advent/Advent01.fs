﻿namespace Advent
open System.IO

module ElvishRucksacksPart1 =
    let ascii_a = 97
    let ascii_z = 122
    let ascii_A = 65
    let ascii_Z = 90

    type PriorizationScore = int
    type RucksackItem = char

    let fileToLines (inputFilePath : string) =
        File.ReadAllLines(inputFilePath)

    let priortization (i : RucksackItem) : PriorizationScore =
        match ((int)i) with
        | i when i >= ascii_a && i <= ascii_z -> (i - ascii_a) + 1
        | i when i >= ascii_A && i <= ascii_Z -> (i - ascii_A) + 27
        | _ -> raise(System.ArgumentException("Unexpected match.")) 

    let scanRucksack(r : string) = 
        r 
        |> Seq.splitInto(2) 
        |> Seq.map Set.ofSeq // builds Sets to support intersections
        |> Set.intersectMany 
        |> Set.map priortization
        |> Seq.sum

    let calculateAll(rucksacks : string seq) =
        rucksacks
        |> Seq.map(fun x -> scanRucksack x)
        |> Seq.sum
        
