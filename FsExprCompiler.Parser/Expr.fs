module Expr

type value =
    | Double of double
    | Variable of string

type op = Add | Sub | Mul | Div

type expr =
    | Value of value
    | Expr of (expr * op * expr)