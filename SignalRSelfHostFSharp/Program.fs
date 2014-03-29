namespace Program

open Owin
open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open Microsoft.Owin.Hosting
open Microsoft.Owin.Cors
open System
open System.Diagnostics
open EkonBenefits.FSharp.Dynamic


type MyHub =
    inherit Hub
    member x.Send (name : string) (message : string) =
        base.Clients.All?addMessage(name,message) |> ignore
(*
type MyHub =
    inherit Hub
    member x.Send (name : string) (message : string) =
        base.Clients.All?addMessage name message


type MyWebStartUp() =
    member x.Configuration (app :IAppBuilder) =
        app.UseCors CorsOptions.AllowAll |> ignore
        app.MapSignalR() |> ignore
        ()

*)

module Starter =

    [<EntryPoint>]
    let main argv = 
        let startup (a:IAppBuilder) =
            a.UseCors(CorsOptions.AllowAll) |> ignore
            a.MapSignalR() |> ignore

        let hostUrl = "http://localhost:8085"
        use app = WebApp.Start(hostUrl, startup)
        //let disposable = WebApp.Start<MyWebStartUp>(hostUrl)
        Console.WriteLine("Server running on "+ hostUrl)
        Console.ReadLine() |> ignore
        //disposable.Dispose() 
        0 // return an integer exit code