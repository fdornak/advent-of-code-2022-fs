module AoC22.Day4Test

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Day 4`` () =
    Day4.firstStar () |> should equal 602
    Day4.secondStar () |> should equal 891
