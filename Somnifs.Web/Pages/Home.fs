module Home

open Elmish
open Feliz
open Feliz.Router
open Feliz.UseElmish

let private home' () =
    Html.article [ prop.text "Home"]


let Page = React.functionComponent("Home", home')
