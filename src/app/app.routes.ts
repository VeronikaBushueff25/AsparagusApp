import { Routes } from '@angular/router';
import { FormComponent } from './form/form.component';
import { FeedComponent } from './feed/feed.component';

export const routes: Routes = [
  { path: '', component: FormComponent },
  { path: 'feed', component: FeedComponent }
];