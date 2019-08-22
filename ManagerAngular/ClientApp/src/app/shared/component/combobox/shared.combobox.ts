import { Component,Input } from '@angular/core';

@Component({
  selector: 'shared-combobox',
  templateUrl: './shared.combobox.html',
})
export class ComboBoxComponent {
  @Input()
  public Items: ComboBoxItemModel[]

  constructor() {
  }
}

export class ComboBoxItemModel {
  public Text: string
  public Value: number

  constructor(text: string, value: number) {
    this.Text = text;
    this.Value = value;
  }
}
