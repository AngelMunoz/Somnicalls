module NotFound

open Elmish
open Feliz
open Feliz.Router
open Feliz.UseElmish


let private notFound' () =
    Html.article [ prop.text "NotFound"]


let Page = React.functionComponent("NotFound", notFound')
