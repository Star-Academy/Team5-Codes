import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  @Input()
  public resultText: string;

  constructor() {
    this.resultText = '';
  }

  ngOnInit(): void {
  }

}
