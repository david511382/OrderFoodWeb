export  default class Node {
  public Text: string
  public Nodes: Node[]
  public Event:EventListener

  constructor(text: string, eventName: EventListener, nodes: Node[]) {
    this.Text = text;
    this.Event = eventName;
    this.Nodes = nodes;
  }
}
