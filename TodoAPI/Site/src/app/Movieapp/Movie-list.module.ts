import { NgModule } from "@angular/core";
import { MovieListRoutingModule } from "./Movie-list-routing.module";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { FilmListPageComponent } from "./movie-film-app-page/film-page.component";
import {  FilmListItemComponent } from "./movie-app-film-item/movie-app-film-item.component";
import { MatIconModule } from "@angular/material/icon";
import { FilmService } from "./Shared/film.service";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@NgModule({
    declarations: [
        FilmListItemComponent,
        FilmListPageComponent
    ],
    imports: [
        HttpClientModule,
        MatButtonModule,
        MatCardModule,
        MatListModule,
        MovieListRoutingModule,
        CommonModule,
        MatIconModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule
    ],
    providers: [
        FilmService
    ]
})
export class MovieListModule {
}