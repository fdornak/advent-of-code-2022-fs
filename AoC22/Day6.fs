module AoC22.Day6

open System.IO

let private input: string =
    (File.ReadAllText "day6.txt")

let private hasUniqueCharacters (str: char []) : bool =
    let uniqueLength =
        str |> Array.distinct |> Array.length

    uniqueLength <> str.Length

let private findNonUniqueMarkerIndex (windowLength: int) (str: string) : int =
    str
    |> Seq.windowed windowLength
    |> Seq.takeWhile hasUniqueCharacters
    |> Seq.length
    |> (fun x -> x + windowLength)

let firstStar () : int = input |> findNonUniqueMarkerIndex 4

let secondStar () : int = input |> findNonUniqueMarkerIndex 14
