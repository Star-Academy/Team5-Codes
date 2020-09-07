import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import { SearchService } from './Service/SearchService';


@Component({
  selector: 'app-home-body',
  templateUrl: './home-body.component.html',
  styleUrls: ['./home-body.component.scss']
})
export class HomeBodyComponent implements OnInit {
  public result: string;

  constructor(private service: SearchService) { }

  // tslint:disable-next-line:typedef
  async ngOnInit() {
    this.searchPhrase('');
  }
  // tslint:disable-next-line:typedef
  public async searchPhrase(value: string) {
    this.result = await this.service.searchRequest(value);
  }
}
