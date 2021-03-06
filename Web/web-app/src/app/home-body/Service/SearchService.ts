import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class SearchService {

  constructor(private http: HttpClient) {
  }

  public async searchRequest(searchKey: string): Promise<string> {
    const header: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return new Promise<string>((resolve) => {
      this.http.post('https://localhost:5001/Main/Get', JSON.stringify(searchKey), {headers: header, responseType: 'text'})
        .subscribe((result: string) => {
          resolve(result);
        });
    });
  }
}
