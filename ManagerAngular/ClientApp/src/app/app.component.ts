import { Component } from '@angular/core';
import Node from './shared/model/model.node';

import { stationList } from './test.const';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  list = stationList;
  public color: string = "green";
  public condition: boolean = true;
  public now: Date = new Date();
  public Nodes: Node[];

  constructor() {
    setInterval(() => {
      this.now = new Date();
    }, 1);

    this.Nodes = [
      new Node(
        "TEST1ttttttt",
        null,
        [
          new Node(
            "TEST1-1",
            null,
            [new Node(
              "TEST1-1-1",
              null,
              []
            )]
          )
        ]
      ),
      new Node("TEST2", null, [new Node(
        "TEST2-1",
        null,
        []
      )])
    ];
  }

  public click(event) {
    this.condition = !this.condition;
  }
}
