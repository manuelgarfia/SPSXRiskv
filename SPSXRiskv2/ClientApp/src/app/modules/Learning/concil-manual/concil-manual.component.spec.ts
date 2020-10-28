import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConcilManualComponent } from './concil-manual.component';

describe('ConcilManualComponent', () => {
  let component: ConcilManualComponent;
  let fixture: ComponentFixture<ConcilManualComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConcilManualComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConcilManualComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
