module AoC22.Day1Test

open Xunit
open FsUnit.Xunit


[<Fact>]
let ``Day 1`` () =
    Day1.firstStar () |> should equal 69626
    Day1.secondStar () |> should equal 206780
