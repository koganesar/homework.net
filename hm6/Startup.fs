namespace hm6

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open hm6.CalculatorHandler


type Startup() =
    
    let webApp =
            choose [route "/ping" >=> text "pong"
                    route "/calculate" >=> calculatorHttpHandler]
    member _.ConfigureServices(services: IServiceCollection) =
            services.AddGiraffe() |> ignore

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
            app.UseGiraffe webApp
            app.Use |> ignore