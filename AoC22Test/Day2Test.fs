module AoC22.Day2Test

open Xunit
open FsUnit.Xunit


[<Fact>]
let ``Day 2`` () =
    Day2.firstStar () |> should equal 13809
    Day2.secondStar () |> should equal 12316
