import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) {
  }

  // will return a string we should add a token at server side and tokenize it after receiving it
  public async searchRequest(searchKey: string): Promise<string> {
    alert(searchKey + ' received the request doesn\'t work');
    return new Promise<string>((resolve) => {
      this.http.post('https://localhost:5001/Main/Get', searchKey, {headers: {'Content-Type': 'application/json', accept: '*/*'}})
        .subscribe((result: string) => {
          resolve(result);
        });
    });
  }
}
