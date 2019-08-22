import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UnlessDirective, HighlightDirective } from './test.unless';
import TreeNodeComponent from './shared/component/shared.treenode';
import ExtenderDirective from './shared/shared.extender';
import { ComboBoxComponent } from './shared/component/combobox/shared.combobox';
import { TestComponent } from './test/test.component';
import { MenuConfigService } from './config/config.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TestComponent,
    UnlessDirective,
    HighlightDirective,
    TreeNodeComponent,
    ExtenderDirective,
    ComboBoxComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'test', component: TestComponent },
    ])
  ],
  providers: [
    MenuConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: (configService: MenuConfigService) => function () { return configService.Load() },
      deps: [MenuConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
