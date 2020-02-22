import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

@NgModule({
  imports: [MatToolbarModule, MatIconModule, MatDividerModule],
  exports: [MatToolbarModule, MatIconModule, MatDividerModule]
})
export class MaterialModule { }
