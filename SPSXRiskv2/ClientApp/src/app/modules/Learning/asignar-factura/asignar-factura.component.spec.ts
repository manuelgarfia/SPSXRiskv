import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignarFacturaComponent } from './asignar-factura.component';

describe('AsignarFacturaComponent', () => {
  let component: AsignarFacturaComponent;
  let fixture: ComponentFixture<AsignarFacturaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsignarFacturaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsignarFacturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
