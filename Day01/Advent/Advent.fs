namespace Advent
open System
open System.IO
open FSharpx

type ElvenCaloriesList = int seq seq
type SummarizedElvenCaloriesList = int seq

module Elves =
    let fileToLines (inputFilePath : string) =
        File.ReadAllLines(inputFilePath)

    let parseElvenCaloriesList (input : string seq) =
        input
        |> String.concat "$"
        |> String.splitString [|"$$"|] StringSplitOptions.None 
        |> Seq.map ((String.splitString [|"$"|] StringSplitOptions.None))
        |> Seq.map (fun i -> i |> Seq.map int)

    let summarizePerElve (input : ElvenCaloriesList) : SummarizedElvenCaloriesList =
        input |> Seq.map (fun i -> i |> Seq.fold (+) 0) 

    let highestSum (input : ElvenCaloriesList) = 
        input
        |> summarizePerElve
        |> Seq.max

    let topThreeSum (input : ElvenCaloriesList) = 
        input
        |> summarizePerElve
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.sum

