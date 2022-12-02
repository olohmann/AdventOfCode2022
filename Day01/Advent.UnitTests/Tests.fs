namespace Advent.UnitTests

open System
open Advent
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestData = 
    [<TestClass>]
    type Day01 () =
        let input = """1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"""   

        [<TestMethod>]
        member this.Support1_InputDataIsParsed_Successful () =
            let individualElvenCalories = 
                Elves.parseElvenCaloriesList (input.Split Environment.NewLine) 
                |> Elves.summarizePerElve
                |> Seq.toArray
            
            let expectedIndividualElvenCalories = [| 6000; 4000; 11000; 24000; 10000 |]
            CollectionAssert.AreEqual(expectedIndividualElvenCalories, individualElvenCalories)

        [<TestMethod>]
        member this.Task1 () =
            let highestCalories = 
                Elves.parseElvenCaloriesList (input.Split Environment.NewLine) 
                |> Elves.highestSum
            
            Assert.AreEqual(24000, highestCalories)

        [<TestMethod>]
        member this.Task2 () =
            let highestCalories = 
                Elves.parseElvenCaloriesList (input.Split Environment.NewLine) 
                |> Elves.topThreeSum
            
            Assert.AreEqual(45000, highestCalories)

