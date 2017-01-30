module Compiler

open System
open Expr
open Microsoft.FSharp.Text.Lexing

let compile (expression:string) = 

    let resolve value variableResolver =
        match value with
        | Double (double) -> double
        | Variable (var)  -> variableResolver var

    let rec combine expr1 expr2 op variableResolver =
        let apply operator = operator (eval expr1 variableResolver) (eval expr2 variableResolver)
        match op with
        | Add -> apply (+)
        | Sub -> apply (-)
        | Mul -> apply (*)
        | Div -> apply (/)

    and eval expr variableResolver =
        match expr with
        | Value (value)           -> resolve value variableResolver
        | Expr (expr1, op, expr2) -> combine expr1 expr2 op variableResolver

    let lexbuf = expression |> LexBuffer<_>.FromString
    let parse = ExprParser.start ExprLexer.tokenize
    let expr = lexbuf |> parse

    eval expr