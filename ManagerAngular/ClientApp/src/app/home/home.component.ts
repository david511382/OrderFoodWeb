import { Component} from '@angular/core';
import { ComboBoxItemModel } from '../shared/component/combobox/shared.combobox';
import { HomeService, ShopModel } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HomeService]
})
export class HomeComponent {
  Items: ComboBoxItemModel[] = []

  constructor(private service: HomeService) {
    service.GetShops()
      .subscribe(shops => {
        for (let i = 0; i < shops.length; i++) {
          let shop = shops[i];
          this.Items.push(new ComboBoxItemModel(shop.name, shop.id));
        }
      });
  }
}
