import { Component, OnInit } from '@angular/core';
import { IFilm } from "../Shared/film.interface";
import { ISeance } from "../Shared/seance.interface";
import { ITickets } from "../Shared/tickets.interface";
import { FilmService } from "../Shared/film.service";
import {MatExpansionModule} from '@angular/material/expansion';
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import {MatCardModule} from '@angular/material/card'; 


@Component({
    selector:'film-list-page',
    templateUrl: './film-list-component.html',
    styleUrls: [],
    providers: [FilmService]
})

export class FilmListPageComponent implements OnInit {
    public items: IFilm[]=[];
    public form!: FormGroup;
    dateStartControl:any;

    constructor(private filmService: FilmService) {
        this.reloadFilm();
    }

    public reloadFilm(): void {
        this.filmService.getFilm().subscribe(films => {
            this.items = films;
        })
    }

    

    public ngOnInit(): void {
        this.form = new FormGroup({
            id: new FormControl(null),
            denomination: new FormControl(null, [Validators.required]),
            dateStart: new FormControl(null, [Validators.required]),
            company: new FormControl(null, [Validators.required])
        });
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.filmService.addFilm({
            id: this.idControl.value,
            denomination: this.denominationControl.value,
            dateStart: this.dateStartControl.value,
            company: this.companyControl.value
        }).subscribe(() => {
            this.reloadFilm();
            this.denominationControl.setValue;
            this.dateStartControl.setValue;
            this.companyControl.setValue;
            this.form.markAsUntouched();
        });
    }

    public updateFilm(): void {
        this.filmService.updateFilm({
                id: this.idControl.value,
                denomination: this.denominationControl.value,
                dateStart: this.dateStartControl.value,
                company: this.companyControl.value
        }).subscribe(() => {
            this.reloadFilm();
            this.denominationControl.setValue(null);
            this.dateStartControl.setValue(null);
            this.companyControl.setValue(null);
            this.form.markAsUntouched();
        });
    }
   

    public deleteFilm(todo: IFilm): void {
        this.filmService.deleteFilmById(todo.id).subscribe(() => {
            this.reloadFilm();
        });
    }

    get idControl(): AbstractControl {
        return this.form.get('id');
    }

    get denominationControl(): AbstractControl {
        return this.form.get('denomination');
    }

    get dateStartNumberControl(): AbstractControl {
        return this.form.get('dateStart');
    }
    
    get companyControl(): AbstractControl {
        return this.form.get('company');
    }
}