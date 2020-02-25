import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDividerModule} from '@angular/material/divider';

@NgModule({
  imports: [MatToolbarModule, MatIconModule, MatCardModule, MatTabsModule, MatFormFieldModule, MatCheckboxModule, MatButtonModule, MatDividerModule, MatInputModule],
  exports: [MatToolbarModule, MatIconModule, MatCardModule, MatTabsModule, MatFormFieldModule, MatCheckboxModule, MatButtonModule, MatDividerModule, MatInputModule]
})
export class MaterialModule { }
