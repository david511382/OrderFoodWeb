import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { MenuConfigService, ConfigModel} from '../config/config.service';

export interface ShopModel {
  id: number
  name: string
}

@Injectable()
export class HomeService{
  private _config: ConfigModel

  constructor(private http: HttpClient, configService: MenuConfigService) {
    this._config = configService.Config;
  }

  GetShops() {
    return this.http.get<ShopModel[]>(this._config.MenuUrl)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };
}
