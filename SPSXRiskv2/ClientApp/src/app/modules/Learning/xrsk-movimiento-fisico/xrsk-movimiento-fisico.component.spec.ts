import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XrskMovimientoFisicoComponent } from './xrsk-movimiento-fisico.component';

describe('XrskMovimientoFisicoComponent', () => {
  let component: XrskMovimientoFisicoComponent;
  let fixture: ComponentFixture<XrskMovimientoFisicoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XrskMovimientoFisicoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XrskMovimientoFisicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
