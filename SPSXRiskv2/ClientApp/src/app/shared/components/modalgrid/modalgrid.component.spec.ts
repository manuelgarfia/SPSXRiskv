import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalgridComponent } from './modalgrid.component';

describe('ModalgridComponent', () => {
  let component: ModalgridComponent;
  let fixture: ComponentFixture<ModalgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
