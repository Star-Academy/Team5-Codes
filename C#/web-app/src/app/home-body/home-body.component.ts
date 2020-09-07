import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {SearchService} from 'src/app/home-body/Service/SearchService';

@Component({
  selector: 'app-home-body',
  templateUrl: './home-body.component.html',
  styleUrls: ['./home-body.component.scss']
})
export class HomeBodyComponent implements OnInit {
  public result: string;

  // constructor(private service: SearchService) { }

  async ngOnInit() {
    this.searchPhrase('labore');
  }
  public async searchPhrase(value: string) {
    // this.result = await this.service.searchRequest(value);
  }
}
