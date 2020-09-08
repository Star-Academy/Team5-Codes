import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {SearchService} from 'src/app/home-body/Service/SearchService';

@Component({
  selector: 'app-home-body',
  templateUrl: './home-body.component.html',
  styleUrls: ['./home-body.component.scss']
})
export class HomeBodyComponent implements OnInit {
  public result: string[];

  constructor(private service: SearchService) { }

  async ngOnInit() {
    this.searchPhrase('!@#$%^&*())dasfasdfasdf');
  }
  public async searchPhrase(value: string) {
    const temp = (await this.service.searchRequest(value)).split('Age:');
    this.result = temp
      .splice(1, temp.length - 1);
  }
}
