import { Component,Input } from '@angular/core';
import Node from '../model/model.node';

@Component({
  selector: 'shared-treenode',
  templateUrl: './shared.treenode.html',
})
export default class TreeNodeComponent {
  @Input()
  public Nodes: Node[]

  constructor() {
  }
}
