namespace Advent.UnitTests

open System
open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Day03 () =
        let input = """vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw"""   

        [<TestMethod>]
        member this.Task1 () =
            Assert.AreEqual(157, ElvishRucksacksPart1.calculateAll (input.Split(System.Environment.NewLine)))

        [<TestMethod>]
        member this.Task2 () =
            Assert.AreEqual(70, ElvishRucksacksPart2.calculateAll (input.Split(System.Environment.NewLine)))



