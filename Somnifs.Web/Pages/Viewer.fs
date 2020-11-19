module Viewer

open Elmish
open Feliz
open Feliz.Router
open Feliz.UseElmish
open Fable.SignalR
open Somnifs.Library


let private viewer' (props: {| hub: IRefValue<Hub<Action, Response>> |}) =
    Html.article [ prop.text "Viewer"]


let Page = React.functionComponent("Viewer", viewer')
