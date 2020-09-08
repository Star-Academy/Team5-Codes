import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-result-container',
  templateUrl: './result-container.component.html',
  styleUrls: ['./result-container.component.scss']
})
export class ResultContainerComponent implements OnInit {

  @Input()
  public results: string[];

  constructor() {
  }

  ngOnInit(): void {
  }

}
