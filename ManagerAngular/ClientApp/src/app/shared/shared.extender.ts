import { Directive, Input, Renderer2, ElementRef} from '@angular/core';
import Node from "./model/model.node"

@Directive({ selector: '[sharedExtender]' })
export  default class ExtenderDirective {
  private tagName: string

  constructor(
    private baseEL: ElementRef,
    private renderer: Renderer2) {
  }

  @Input()
  set sharedExtender(node: Node) {
    const htmlEL: HTMLElement = (this.baseEL.nativeElement as HTMLElement);
    this.tagName = htmlEL.tagName;

    this.setNodeOn(htmlEL, node);
  }

  setNodeOn(htmlEL: HTMLElement,node: Node) {
    htmlEL.innerHTML= node.Text;
    htmlEL.addEventListener('click', node.Event);

    let childrenCount = node.Nodes.length;
    if (childrenCount > 0) {
      let ul: HTMLElement = this.renderer.createElement("ul");
      this.renderer.appendChild(htmlEL, ul);
    
      for (let i = 0; i < childrenCount; i++) {
        let newObj: HTMLElement = this.renderer.createElement(this.tagName);
        let childNode = node.Nodes[i];
        this.renderer.appendChild(ul, newObj);      
        this.setNodeOn(newObj, childNode);
      }
    }
  }
}
