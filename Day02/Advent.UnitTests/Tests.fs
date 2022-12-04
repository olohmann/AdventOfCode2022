namespace Advent.UnitTests

open System
open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Day02 () =
        let input = """A Y
B X
C Z"""   

        [<TestMethod>]
        member this.Task1 () =
            let scores = input.Split(System.Environment.NewLine) |> ElvishRockPaperScissorsStrategy.parseToMatches |> ElvishRockPaperScissorsStrategy.scoreMatches 
            
            Assert.AreEqual(15, scores |> Seq.sum)

        [<TestMethod>]
        member this.Task2 () =
            let scores = input.Split(System.Environment.NewLine) |> ElvishRockPaperScissorsStrategyDecrypted.parseToMatches |> ElvishRockPaperScissorsStrategyDecrypted.scoreMatches 
            
            Assert.AreEqual(12, scores |> Seq.sum)



