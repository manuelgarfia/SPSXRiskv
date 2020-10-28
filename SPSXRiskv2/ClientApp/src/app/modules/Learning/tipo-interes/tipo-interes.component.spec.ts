import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoInteresComponent } from './tipo-interes.component';

describe('TipoInteresComponent', () => {
  let component: TipoInteresComponent;
  let fixture: ComponentFixture<TipoInteresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoInteresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoInteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
