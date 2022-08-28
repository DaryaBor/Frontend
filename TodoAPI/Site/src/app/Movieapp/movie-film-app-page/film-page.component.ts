import { Component, OnInit } from '@angular/core';
import { IFilm } from "../Shared/film.interface";
import { ISeance } from "../Shared/seance.interface";
import { ITickets } from "../Shared/tickets.interface";
import { FilmService } from "../Shared/film.service";
import {MatExpansionModule} from '@angular/material/expansion';
import { AbstractControl, FormControl, FormGroup, Validators, FormBuilder } from "@angular/forms";
import {MatCardModule} from '@angular/material/card'; 


@Component({
    selector:'film-list-page',
    templateUrl: 'film-list-component.html',
    styleUrls: [],
    providers: [FilmService]
})

export class FilmListPageComponent  {
    public items: IFilm[]=[];
    public form!: FormGroup;
    dateStartControl = new FormControl();
    options = this._formBuilder.group({
     id: this.idControl,
    denomination : this.denominationControl,
    dateStart: this.dateStartControl,
    company: this.companyControl,
    });
   
    
    constructor(private _formBuilder: FormBuilder, private filmService: FilmService) {
        //this.reloadFilm();
    }

    //constructor(private filmService: FilmService) {
       //this.reloadFilm();
    //}

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
        });
            this.reloadFilm();
            this.denominationControl.setValue;
            this.dateStartControl.setValue;
            this.companyControl.setValue;
            this.form.markAsUntouched();
        }
    

    public updateFilm(): void {
        this.filmService.updateFilm({
                id: this.idControl.value,
                denomination: this.denominationControl.value,
                dateStart: this.dateStartControl.value,
                company: this.companyControl.value
        });
            this.reloadFilm();
            this.denominationControl.setValue;
            this.dateStartControl.setValue(null);
            this.companyControl.setValue;
            this.form.markAsUntouched();
        };
    
   

    public deleteFilm(todo: IFilm): void {
        this.filmService.deleteFilmById(todo.id) 
            this.reloadFilm();

      
        
    }

    get idControl(): FormControl<number> {
        return this.options.get('id') as FormControl<number> ;
    }

    get denominationControl(): FormControl<string>  {
        return this.form.get('denomination') as  FormControl<string>;
    }

    get dateStartNumberControl():  FormControl<number> {
        return this.form.get('dateStart') as  FormControl<number>;
    }
    
    get companyControl():  FormControl<string> {
        return this.form.get('company') as  FormControl<string>;
    }
}
