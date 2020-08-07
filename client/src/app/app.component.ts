import {
  Component,
  ElementRef,
  ViewChild,
  OnInit
} from '@angular/core';
import {
  CityService
} from './core/city.service';
import {
  City
} from './models/city';
import {
  CityParams
} from './models/city-params';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ValidatorFn,
  AbstractControl,
  FormControl
} from '@angular/forms';
import {
  Observable
} from 'rxjs';
import {
  startWith,
  map,
  debounceTime,
  tap,
  switchMap,
  finalize
} from 'rxjs/operators';
import {
  HttpClient
} from '@angular/common/http';
import * as converter from 'xml-js';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  @ViewChild('search', {
    static: true
  }) searchTerm: ElementRef;
  filteredUsers: City[] = [];
  cityForm: FormGroup;
  isLoading = false;

  title = 'client';
  cityParams = new CityParams();
  city: City;
  visibleForm = true;
  date: Date;

  constructor(private fb: FormBuilder, private cityService: CityService, private http: HttpClient) {

  }

  getCityDetails() {

    this.cityService.getCityDetails(this.cityParams).subscribe(res => {
      this.city = res;
      this.visibleForm = false;
      this.date = new Date();
      console.log(res);

    }, error => console.log(error));


  }

  ngOnInit() {
    this.cityForm = this.fb.group({
      nome: null,
      id: null,
    })

    this.cityForm
      .get('nome')
      .valueChanges
      .pipe(
        debounceTime(300),
        tap(() => this.isLoading = true),
        switchMap(value => this.search({
            name: value
          }, 1)
          .pipe(
            finalize(() => this.isLoading = false),
          )
        )
      )
      .subscribe(users => {
        let result1 = converter.xml2json(users, {
          compact: true,
          spaces: 2
        });

        const JSONData = JSON.parse(result1);
        let jsonResult = JSONData.cidades.cidade;
        let list = [];

        jsonResult.map(option => {
          list.push({
            id: option.id._text.toLowerCase(),
            nome: option.nome._text.toLowerCase(),
          })
        });
        this.filteredUsers = list

      });
  }

  search(filter: {
    name: string
  } = {
    name: ''
  }, page = 1): Observable < any[] > {
    return this.http.get(`http://servicos.cptec.inpe.br/XML/listaCidades?city=${filter.name}`, {
      responseType: 'text'
    })
      .pipe(
        tap((response: any) => {
          let result1 = converter.xml2json(response, {
            compact: true,
            spaces: 2
          });

          const JSONData = JSON.parse(result1);
          let jsonResult = JSONData.cidades.cidade;
          let list = [];

          jsonResult.map(option => {
            list.push({
              id: option.id._text.toLowerCase(),
              nome: option.nome._text.toLowerCase(),
            })
          });
          response = list
            .map(user => {
              let cityJson:City = {};
              cityJson = user;
              return cityJson;
            })
            // Not filtering in the server since in-memory-web-api has somewhat restricted api
            .filter(user => {

              return user.nome.toLowerCase().includes(filter.name)

            })

          return response;
        })
      );
  }


  onSearch() {
    this.cityParams.id = this.cityForm.get('id').value;
    this.getCityDetails();
  }

  updateMySelection(option) {
console.log(option)
    this.cityForm.patchValue({
      nome: option.source.value.nome,
      id: option.source.value.id
    });
  }



}
