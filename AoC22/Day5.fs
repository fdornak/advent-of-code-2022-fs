module AoC22.Day5

open System.Text.RegularExpressions
open System.IO

type MovementOrder = { Count: int; From: int; To: int }

type State = array<list<char>>

let fileSplitByLines: string [] =
    (File.ReadAllText "day5.txt").Split("\r\n")
    |> Array.skip 10
    |> Array.filter (fun str -> not (Seq.isEmpty str))

let initialState: State =
    [| [ 'R'; 'W'; 'F'; 'H'; 'T'; 'S' ]
       [ 'W'; 'Q'; 'D'; 'G'; 'S' ]
       [ 'W'; 'T'; 'B' ]
       [ 'J'; 'Z'; 'Q'; 'N'; 'T'; 'W'; 'R'; 'D' ]
       [ 'Z'; 'T'; 'V'; 'L'; 'G'; 'H'; 'B'; 'F' ]
       [ 'G'; 'S'; 'B'; 'V'; 'C'; 'T'; 'P'; 'L' ]
       [ 'P'; 'G'; 'W'; 'T'; 'R'; 'B'; 'Z' ]
       [ 'R'; 'J'; 'C'; 'T'; 'M'; 'G'; 'N' ]
       [ 'W'; 'B'; 'G'; 'L' ] |]

let orderRegex =
    Regex("move\\s+(\\d+)\\s+from\\s+(\\d+)\\s+to\\s+(\\d+)", RegexOptions.Compiled)

let parseMovementOrder (str: string) : MovementOrder =
    let m = orderRegex.Match(str)
    let countVal = int m.Groups[1].Value
    let fromVal = int m.Groups[2].Value - 1
    let toVal = int m.Groups[3].Value - 1

    { Count = countVal
      From = fromVal
      To = toVal }

let doOneMovement9000 (state: State) ((fromI, toI): int * int) : State =
    let poppedChar = state[fromI].Head

    state
    |> Array.mapi (fun i v ->
        match i with
        | i when i = fromI -> v.Tail
        | i when i = toI -> poppedChar :: v
        | _ -> v)

let processMovementOrder9000 (state: State) (order: MovementOrder) : State =
    Seq.init order.Count (fun _ -> (order.From, order.To))
    |> Seq.fold doOneMovement9000 state

let processMovementOrder9001 (state: State) (order: MovementOrder) : State =
    let listToBeMoved =
        List.take order.Count state[order.From]

    state
    |> Array.mapi (fun i v ->
        match i with
        | i when i = order.From -> List.skip order.Count v
        | i when i = order.To -> listToBeMoved @ v
        | _ -> v)

let firstStar () : string =
    fileSplitByLines
    |> Array.map parseMovementOrder
    |> Array.fold processMovementOrder9000 initialState
    |> Array.map (fun x -> x.Head)
    |> System.String

let secondStar () : string =
    fileSplitByLines
    |> Array.map parseMovementOrder
    |> Array.fold processMovementOrder9001 initialState
    |> Array.map (fun x -> x.Head)
    |> System.String
