module AoC22.Day3Test

open Xunit
open FsUnit.Xunit


[<Fact>]
let ``Day 3`` () =
    Day3.firstStar () |> should equal 7875
    Day3.secondStar () |> should equal 2479
