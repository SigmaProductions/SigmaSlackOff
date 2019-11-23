import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoolthanksComponent } from './coolthanks.component';

describe('CoolthanksComponent', () => {
  let component: CoolthanksComponent;
  let fixture: ComponentFixture<CoolthanksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoolthanksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoolthanksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
