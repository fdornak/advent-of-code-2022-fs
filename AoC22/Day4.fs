module AoC22.Day4

open System.IO

type private Sectors = { First: int * int; Second: int * int }

let private fileSplitByLines: string [] =
    (File.ReadAllText "day4.txt").Split("\r\n")
    |> Array.filter (fun str -> not (Seq.isEmpty str))

let private parseIntoSectors (str: string) : Sectors =
    let split = str.Split(',')

    let splitByDashAndMap (s: string) = s.Split('-') |> Array.map int

    let first = splitByDashAndMap split[0]
    let second = splitByDashAndMap split[1]

    let fRange = (first[0], first[1])
    let sRange = (second[0], second[1])

    { First = fRange; Second = sRange }

let private isOneFullyContained (sectors: Sectors) : bool =
    match sectors with
    | { First = (fa, fb); Second = (sa, sb) } when (sa >= fa && sb <= fb) || (fa >= sa && fb <= sb) -> true
    | _ -> false

let private isAnyOverlap (sectors: Sectors) : bool =
    match sectors with
    //fully contained
    | sectors when isOneFullyContained sectors -> true
    //left overlap
    | { First = (fa, _); Second = (sa, sb) } when (fa >= sa && fa <= sb) -> true
    //right overlap
    | { First = (_, fb); Second = (sa, sb) } when (fb >= sa && fb <= sb) -> true
    | _ -> false

let firstStar () : int =
    fileSplitByLines
    |> Array.map parseIntoSectors
    |> Array.map isOneFullyContained
    |> Array.filter (fun x -> x = true)
    |> Array.length

let secondStar () : int =
    fileSplitByLines
    |> Array.map parseIntoSectors
    |> Array.map isAnyOverlap
    |> Array.filter (fun x -> x = true)
    |> Array.length
