import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) {
  }

  // will return a string we should add a token at server side and tokenize it after receiving it
  public async searchRequest(searchkey: string): Promise<string> {
    return new Promise<string>((resolve) => {
      this.http.post('https://localhost:5001/Main/Get', { searchkey }).subscribe((result: string) => {
        resolve(result);
      });
    });
  }
}
